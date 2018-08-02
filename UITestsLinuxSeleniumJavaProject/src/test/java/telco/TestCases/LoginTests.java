package telco.TestCases;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import Data.Login;
import Data.URL;
import telco.Pages.LoginPage;

public class LoginTests extends BaseTest {
	LoginPage loginPage;
	
	@Before
	public void initializePage() {
		this.initialize();
		this.loginPage = new LoginPage(this.driver);
	}

	@Test
	public void validCredentialLoginTest() {
		this.loginPage.login(Login.validUsername, Login.validPassword);

		Assert.assertEquals(driver.getCurrentUrl(), URL.homePageUrl);
	}

	@Test
	public void invalidUsernameLoginTest() {
		loginPage.login(Login.invalidUsername, Login.validPassword);

		Assert.assertTrue(loginPage.errorInvalidCredentialsIsVisible());
	}

	@Test
	public void invalidPasswordLoginTest() {
		loginPage.login(Login.validUsername, Login.invalidPassword);

		Assert.assertTrue(loginPage.errorInvalidCredentialsIsVisible());
	}

	@Test
	public void missingUsernameLoginTest() {
		loginPage.login("", Login.validPassword);

		Assert.assertTrue(loginPage.errorMissingUsernameVisible());
	}

	@Test
	public void missingPasswordLoginTest() {
		loginPage.login(Login.validUsername, "");

		Assert.assertTrue(loginPage.errorMissingPasswordVisible());
	}
}
