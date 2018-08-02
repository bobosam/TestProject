package telco.TestCases;

import java.util.concurrent.TimeUnit;

import org.junit.After;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import Data.Browser;
import Data.URL;

public class BaseTest {
	WebDriver driver;

	public void initialize() {
		System.setProperty(Browser.firefox, Browser.firefoxDriverPath);
		driver = new FirefoxDriver();
		driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
		driver.manage().window().maximize();
		driver.get(URL.telcoUrl);
	}

	@After
	public void tearDown() {
		driver.quit();
	}
}
