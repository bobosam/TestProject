package telco.Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class LoginPage extends BasePage {
	By username = By.id("id_username");
	By password = By.id("id_password");
	By connect = By.id("loginBtn");
	By invalidCredential = By.xpath("/html/body/div[1]/div/div/form/div/div[2]/fieldset/div[1]/p");
	By missingUsername = By.xpath("/html/body/div[1]/div/div/form/div/div[2]/fieldset/div[1]/span[2]");
	By missingPassword = By.xpath("/html/body/div[1]/div/div/form/div/div[2]/fieldset/div[2]/span[2]");

	public LoginPage(WebDriver driver) {
		super(driver);
	}
	
	public boolean errorInvalidCredentialsIsVisible() {
		return driver.findElements(invalidCredential).size() == 1; 
	}
	
	public boolean errorMissingUsernameVisible() {
		return driver.findElements(missingUsername).size() == 1; 
	}
	
	public boolean errorMissingPasswordVisible() {
		return driver.findElements(missingPassword).size() == 1; 
	}

	public void login(String user, String pass) {
		driver.findElement(username).sendKeys(user);
		driver.findElement(password).sendKeys(pass);
		driver.findElement(connect).click();
	}
}
