package telco.Pages;

import java.util.concurrent.TimeUnit;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;

import Data.Port;
import Data.Subnet;

public class CurrentNetworkPage extends BasePage {
	By options = By.xpath("/html/body/div[2]/div[2]/div[1]/div/div/div[2]/div/div[2]/form/div/a[2]/span");
	By deleteNetwork = By.xpath("//*[contains(text(),' Delete Network')]");
	By confirmDelete = By.xpath("//a[contains(text(),'Delete Network')]");
	By subnets = By.xpath("//a[contains(text(),'Subnets')]");
	By createSubnet = By.id("subnets__action_create");
	By subnetName = By.id("id_subnet_name");
	By networkAddress = By.id("id_cidr");
	By createSubnetNext = By.xpath("//button[contains(text(),'Next')]");
	By createSubnetCancel = By.xpath("//a[contains(text(),'Cancel')]");
	By createSubnetButton = By.xpath("//button[contains(text(),'Create')]");
	By addedSubnet = By.xpath("//*[contains(text(), '" + Subnet.subnetName + "')]");
	By ports = By.xpath("//a[contains(text(),'Ports')]");
	By createPort = By.id("ports__action_create");
	By portName = By.id("id_name");
	By selectSpecifyIP = By.id("id_specify_ip");
	By createPortButton = By.xpath("//input[@value='Create Port']");
	By addedPort = By.xpath("//*[contains(text(), '" + Port.portName + "')]");

	public CurrentNetworkPage(WebDriver driver) {
		super(driver);
	}

	public boolean addedSubnetVisible() {
		return driver.findElements(addedSubnet).size() == 1;
	}

	public void openAddedSubnet() {
		driver.findElement(addedSubnet).click();
	}

	public void cancelAddedSubnet() {
		driver.findElement(createSubnetCancel).click();
	}

	public void fillSubnetForm(String name, String address) {
		driver.findElement(createSubnet).click();
		driver.findElement(subnetName).sendKeys(name);
		driver.findElement(networkAddress).sendKeys(address);
		driver.findElement(createSubnetNext).click();
		try {
			driver.findElement(createSubnetButton).click();
		} catch (Exception e) {
		}
	}

	public void openSubnets() {
		driver.findElement(subnets).click();
	}

	public void openPorts() {
		driver.navigate().refresh();
		driver.findElement(ports).click();
	}

	public void fillPortForm(String name, String specifyIP) {
		driver.findElement(createPort).click();
		driver.findElement(portName).sendKeys(name);
		WebElement specifySelect = driver.findElement(selectSpecifyIP);
		new Select(specifySelect).selectByVisibleText(specifyIP);
		driver.findElement(createPortButton).click();
	}

	public boolean addedPortVisible() {
		return driver.findElements(addedPort).size() == 1;
	}

	public void openAddedPort() {
		driver.findElement(addedPort).click();
	}

	public void deleteNetwork() throws InterruptedException {
		driver.findElement(options).click();
		TimeUnit.SECONDS.sleep(1);
		driver.findElement(deleteNetwork).click();
		TimeUnit.SECONDS.sleep(1);
		driver.findElement(confirmDelete).click();
	}
}
