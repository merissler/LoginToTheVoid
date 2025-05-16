using Konscious.Security.Cryptography;
using LoginToTheVoid.JsonObjects;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LoginToTheVoid;

public partial class frmMain : Form
{
    private readonly Color _ogGud;
    private readonly Color _ogBad;
    private readonly Connector _connector = new("192.168.90.210", "randomstuff", "postgres", "postgres");

    public frmMain()
    {
        InitializeComponent();
        _ogGud = gud.ForeColor;
        _ogBad = bad.ForeColor;
        gud.ForeColor = SystemColors.ControlText;
        bad.ForeColor = SystemColors.ControlText;

        CheckForUpdatesAsync();
    }

    private async void CheckForUpdatesAsync()
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("agent");

            var response = await client.GetAsync("https://api.github.com/repos/merissler/LoginToTheVoid/releases/latest");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var release = JsonSerializer.Deserialize<GithubRelease>(json) ?? throw new Exception("Failed to parse json: " + json);

            string current = Program.Version.Trim();
            string latest = release.TagName.Trim();
            if (current.Equals(latest, StringComparison.OrdinalIgnoreCase))
            {
                lbUpdate.Text = "No new versions available";
            }
            else
            {
                lbUpdate.Text = "A new version is available";
                llInstall.Visible = true;
                llInstall.Location = new(lbUpdate.Right + lbUpdate.Margin.Right + llInstall.Margin.Left, lbUpdate.Top);
                llInstall.Click += (_, _) =>
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = release.Assets[0].BrowserDownloadUrl,
                        UseShellExecute = true,
                    });
                };
            }
        }
        catch (Exception ex)
        {
            lbUpdate.Text = "Error occurred while checking for updates:" + Environment.NewLine + ex.Message;
            lbUpdate.ForeColor = Color.Red;
        }
    }

    private void login_Click(object sender, EventArgs e)
    {
        LoginAsync(usa.Text, passwad.Text);
    }

    private void newusa_Click(object sender, EventArgs e)
    {
        CreateUserAsync(usa.Text, passwad.Text);
    }

    private async void CreateUserAsync(string name, string password)
    {
        try
        {
            Enabled = false;

            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                MemorySize = 65536,
                Iterations = 4,
            };
            byte[] hashBytes = await argon2.GetBytesAsync(32);

            string hashBase64 = Convert.ToBase64String(hashBytes);
            string saltBase64 = Convert.ToBase64String(salt);

            var user = new User()
            {
                Name = name,
                PasswordHash = hashBase64,
                PasswordSalt = saltBase64,
            };
            await user.InsertAsync(_connector);
        }
        catch (Exception ex)
        {
            gud.ForeColor = SystemColors.ControlText;
            bad.ForeColor = _ogBad;
            message.Text = ex.Message;
        }
        finally
        {
            Enabled = true;
        }
    }

    private async void LoginAsync(string name, string password)
    {
        try
        {
            Enabled = false;

            (string? storedHash, string? storedSalt) = await GetHashAndSalt(name);
            if (storedHash is not null && storedSalt is not null)
            {
                byte[] saltBytes = Convert.FromBase64String(storedSalt);

                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
                {
                    Salt = saltBytes,
                    DegreeOfParallelism = 4,
                    MemorySize = 65536,
                    Iterations = 4,
                };
                byte[] hashBytes = await argon2.GetBytesAsync(32);
                string computedHash = Convert.ToBase64String(hashBytes);

                if (computedHash == storedHash)
                {
                    gud.ForeColor = _ogGud;
                    bad.ForeColor = SystemColors.ControlText;
                    message.Text = "You are in my guy";
                }
                else
                {
                    gud.ForeColor = SystemColors.ControlText;
                    bad.ForeColor = _ogBad;
                    message.Text = "Wrong";
                }
            }
            else throw new Exception("Usa not found or just don't have passwad");
        }
        catch (Exception ex)
        {
            gud.ForeColor = SystemColors.ControlText;
            bad.ForeColor = _ogBad;
            message.Text = ex.Message;
        }
        finally
        {
            Enabled = true;
        }
    }

    private async Task<(string?, string?)> GetHashAndSalt(string name)
    {
        var col = new UserCollection(_connector);
        col.WhereNameEquals(name);
        await col.LoadAsync();

        if (col.Count == 0) return (null, null);
        else return (col[0].PasswordHash, col[0].PasswordSalt);
    }
}
