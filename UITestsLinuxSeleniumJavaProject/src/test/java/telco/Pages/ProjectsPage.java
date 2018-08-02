package telco.Pages;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class ProjectsPage extends BasePage{

	By adminMenu = By.xpath("//*[@id='sidebar-accordion']/li[2]/a");
	By networks = By.xpath("//*[@id='sidebar-accordion-admin-admin']/a[7]");
	
	public ProjectsPage(WebDriver driver) {
		super(driver);
	}
	
	public void openAdminAccordion() throws InterruptedException {
		driver.findElement(adminMenu).click();
		TimeUnit.SECONDS.sleep(2);
	}

	public void openNetworksPage() {
		driver.findElement(networks).click();
	}
}
