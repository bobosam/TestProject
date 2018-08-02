package telco.Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import Data.Networks;

public class NetworksPage extends BasePage {
	By addNetwork = By.id("networks__action_create");
	By name = By.id("id_name");
	By selectProject = By
			.xpath("//*[@id=\"create_network_form\"]/div[1]/div[1]/fieldset/div[2]/div/div/button/span[1]");
	By providerNetworkType = By
			.xpath("//*[@id=\"create_network_form\"]/div[1]/div[1]/fieldset/div[3]/div/div/button/span[1]");
	By physicalNetwork = By.id("id_physical_network");
	By segmentationID = By.id("id_segmentation_id");
	By submitButton = By.xpath("//*[@id=\"create_network_form\"]/div[2]/input");
	By addedNetwork = By.xpath("//*[contains(text(), '" + Networks.networkName + "')]");
	By requiredElemet = By.xpath("//*[contains(text(), 'This field is required.')]");
	By incorectSegmentationID = By.xpath("//*[contains(text(), 'For a vlan network, valid segmentation IDs are 1 through 4094.')]");

	public NetworksPage(WebDriver driver) {
		super(driver);
	}

	public void openAddNetworkForm() {
		driver.findElement(addNetwork).click();
	}

	public void openAddedNetwork() {
		driver.navigate().refresh();
		driver.findElement(addedNetwork).click();
	}
	
	public boolean errorSegmentationIDVisible() {
		return driver.findElements(incorectSegmentationID).size() == 1;
	}
	
	public boolean requiredElementVisible() {
		return driver.findElements(requiredElemet).size() == 1;
	}

	public boolean addedNetworksVisible() {
		return driver.findElements(addedNetwork).size() == 1;
	}

	public void fillAndSubmitForm(String networkName, String physicalName, String segmentation, String project, String netType) {
		driver.findElement(name).sendKeys(networkName);
		driver.findElement(selectProject).click();
		driver.findElement(By.xpath("//ul/li/a[contains(text(), '" + project + "')]")).click();
		driver.findElement(providerNetworkType).click();
		driver.findElement(By.xpath("//ul/li/a[contains(text(), '" + netType + "')]")).click();
		if (netType.equals(Networks.vlanType)) {
			driver.findElement(physicalNetwork).clear();
			driver.findElement(physicalNetwork).sendKeys(physicalName);
			driver.findElement(segmentationID).sendKeys(segmentation);
		}

		driver.findElement(submitButton).click();
	}
}
