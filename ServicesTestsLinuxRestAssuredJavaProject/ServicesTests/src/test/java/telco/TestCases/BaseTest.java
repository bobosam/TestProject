package telco.TestCases;

import java.util.Set;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.Cookie;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.BeforeMethod;

import com.jayway.restassured.RestAssured;

import Data.Browser;
import Data.Login;
import Data.URL;

public class BaseTest {
	static WebDriver driver;
	static String csrftoken;
	static String sessionid;

	@BeforeClass
	public static void SetUp() {
		System.setProperty(Browser.firefox, Browser.firefoxDriverPath);
		driver = new FirefoxDriver();
		driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
		driver.manage().window().maximize();
		driver.get(URL.telcoUrl);
		driver.findElement(By.id("id_username")).sendKeys(Login.validUsername);
		driver.findElement(By.id("id_password")).sendKeys(Login.validPassword);
		driver.findElement(By.id("loginBtn")).click();	
		Set<Cookie> ss = driver.manage().getCookies();
		for (Cookie cookie : ss) {
			if (cookie.getName().equals("csrftoken")) {
				csrftoken = cookie.getValue();
			}
			
			if (cookie.getName().equals("sessionid")) {
				sessionid = cookie.getValue();
			}
		}
	}

	@BeforeMethod
	public void initialize() {
		try {
			// RestAssured.port = port;
			RestAssured.useRelaxedHTTPSValidation();
			RestAssured.config().getSSLConfig().with().keystore("classpath:keystore.p12", "password");
		} catch (Exception ex) {
			System.out.println("Error while loading keystore >>>>>>>>>");
			ex.printStackTrace();
		}
	}

	@AfterClass
	public static void tearDown() {
		// driver.quit();
	}
}
