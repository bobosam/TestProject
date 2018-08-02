package telco.Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class CurrentPortPage extends BasePage {
	By options = By.xpath("/html/body/div[2]/div[2]/div[1]/div/div/div[2]/div/div[2]/form/div/a[2]/span");
	By deletePort = By.xpath("//button[contains(text(),' Delete Port')]");
	By confirmDelete = By.xpath("//a[contains(text(),' Delete Port')]");
	
	public CurrentPortPage(WebDriver driver) {
		super(driver);
	}
	
	public void deleteAddedPort() {
		driver.findElement(options).click();
		driver.findElement(deletePort).click();
		driver.findElement(confirmDelete).click();
	}
}
