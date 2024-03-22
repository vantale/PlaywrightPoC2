using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightPoC
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task Test()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://cib.societegenerale.pl/en/cib-polska/");
            await page.GetByLabel("Agree and close: Agree to our").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Our Offer" }).ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { Name = "Investment Banking" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "SG Exchange Rates" }).ClickAsync();
            await page.GetByLabel("Go to Exchange rates of the previous day").ClickAsync();
            await page.GetByLabel("Go to Exchange rates of the previous day").ClickAsync();
            await page.GetByLabel("Day", new() { Exact = true }).SelectOptionAsync(new[] { "14" });
            await page.GetByLabel("Month").SelectOptionAsync(new[] { "7" });
            await page.GetByLabel("Load exchange rates").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Locations" }).ClickAsync();
            await page.GetByLabel("SG CIB Warszawa").ClickAsync();
            await page.Locator("#mainGmap").GetByText("SG CIB Warszawa").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "About Us" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "CSR" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Responsible Business" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Contact" }).ClickAsync();
            await page.GetByLabel("Address").ClickAsync();
            await page.GetByLabel("Address").FillAsync("Moj Adress");
            await page.GetByLabel("ZIP code").ClickAsync();
            await page.GetByLabel("ZIP code").FillAsync("");
            await page.GetByLabel("City").ClickAsync();
            await page.GetByLabel("City").FillAsync("Varsovie");
            await page.GetByLabel("Country").ClickAsync();
            await page.GetByLabel("Country").FillAsync("Poland");
            await page.GetByLabel("Email*").ClickAsync();
            await page.GetByLabel("Email*").FillAsync("nie.znam@gmail.com");
            await page.GetByLabel("Phone").ClickAsync();
            await page.GetByLabel("Phone").FillAsync("12345678");
            await page.GetByLabel("Company").ClickAsync();
            await page.GetByLabel("Company").FillAsync("NoName Company");
            await page.GetByLabel("Function").ClickAsync();
            await page.GetByLabel("Function").FillAsync("The boss");
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            await Expect(page.Locator("#tx_powermail_pi1fieldphone-errormessage")).ToContainTextAsync("This is not a valid Phone Number!");
            await Expect(page.Locator("#tx_powermail_pi1fieldsubject-errormessage")).ToContainTextAsync("This field must be filled!");
            await Expect(page.Locator("#tx_powermail_pi1fieldyourmessage-errormessage")).ToContainTextAsync("This field must be filled!");
            await Expect(page.Locator("#tx_powermail_pi1fieldname-errormessage")).ToContainTextAsync("This field must be filled!");
            await Expect(page.Locator("#tx_powermail_pi1fieldsurname-errormessage")).ToContainTextAsync("This field must be filled!");
            await page.GetByRole(AriaRole.Link, new() { Name = "See website in English" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Our Offer" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "SG Exchange Rates" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Locations" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "About Us" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "CSR" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Responsible Business" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Contact" }).ClickAsync();
            await page.GetByLabel("Subject*").ClickAsync();
            await page.GetByLabel("Subject*").ClickAsync();
            await page.GetByLabel("Subject*").FillAsync("????????");
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Search " }).ClickAsync();
            await page.GetByRole(AriaRole.Searchbox, new() { Name = "Search with Quantum" }).FillAsync("exchange rates");
            await page.GetByRole(AriaRole.Searchbox, new() { Name = "Search with Quantum" }).PressAsync("Enter");
            await page.GetByLabel("Go to page: SG Exchange Rates").ClickAsync();
        }
        [Test]
        public async Task Test2()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://www.societegenerale.com/en");
            await page.GetByLabel("Agree and close: Agree to our").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Responsibility" }).ClickAsync();
            await Expect(page.GetByLabel("Main menu")).ToContainTextAsync("News");
            await Expect(page.GetByLabel("Main menu")).ToContainTextAsync("Patronage & Sponsorship");
            await Expect(page.GetByLabel("Main menu")).ToContainTextAsync("Publications & documents");
            await Expect(page.GetByLabel("Main menu")).ToContainTextAsync("Job applicants");
            await page.GetByRole(AriaRole.Link, new() { Name = "Job applicants" }).ClickAsync();
            await page.Locator("#home-bg").GetByText("IT & Digital").ClickAsync();
            await Expect(page.Locator("#block-sg-careers-content")).ToContainTextAsync("« Together, we’re going further, and we’re taking tech banking with us.»");
            await page.GetByLabel("Consulter le site en français").ClickAsync();
            await Expect(page.Locator("#block-sg-careers-content")).ToContainTextAsync("« Ensemble on va plus loin, et on emmène la tech banking avec nous. »");

        }
    }
}