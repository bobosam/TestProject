package telco.TestCases;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import Data.Login;
import Data.URL;
import telco.Pages.LoginPage;
import telco.Pages.ProjectsPage;

public class ProjectsTests extends BaseTest {
	private ProjectsPage projectsPage;
	LoginPage loginPage;

	@Before
	public void initializePage() {
		this.initialize();
		this.projectsPage = new ProjectsPage(this.driver);
		this.loginPage = new LoginPage(this.driver);
	}

	@Test
	public void openNetworksPageTest() throws InterruptedException {
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();

		Assert.assertEquals(driver.getCurrentUrl(), URL.networksPageUrl);
	}
}
