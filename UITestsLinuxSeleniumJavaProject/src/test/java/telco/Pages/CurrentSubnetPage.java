package telco.Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class CurrentSubnetPage extends BasePage {
	By options = By.xpath("/html/body/div[2]/div[2]/div[1]/div/div/div[2]/div/div[2]/form/div/a[2]/span");
	By deleteSubnet = By.xpath("//button[contains(text(),' Delete Subnet')]");
	By confirmDelete = By.xpath("//a[contains(text(),' Delete Subnet')]");
	
	public CurrentSubnetPage(WebDriver driver) {
		super(driver);
	}
	
	public void deleteAddedSubnet() {
		driver.findElement(options).click();
		driver.findElement(deleteSubnet).click();
		driver.findElement(confirmDelete).click();
	}
}
