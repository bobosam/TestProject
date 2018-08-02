package telco.TestCases;

import java.util.concurrent.TimeUnit;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import Data.Login;
import Data.Networks;
import Data.Port;
import Data.Subnet;
import telco.Pages.CurrentNetworkPage;
import telco.Pages.CurrentPortPage;
import telco.Pages.CurrentSubnetPage;
import telco.Pages.LoginPage;
import telco.Pages.NetworksPage;
import telco.Pages.ProjectsPage;

public class CurrentNetworkTests extends BaseTest {
	LoginPage loginPage;
	ProjectsPage projectsPage;
	NetworksPage networksPage;
	CurrentNetworkPage currentNetworkPage;
	CurrentSubnetPage currentSubnetPage;
	CurrentPortPage currentPortPage;

	@Before
	public void initializePage() {
		this.initialize();
		this.loginPage = new LoginPage(this.driver);
		this.projectsPage = new ProjectsPage(this.driver);
		this.networksPage = new NetworksPage(this.driver);
		this.currentNetworkPage = new CurrentNetworkPage(this.driver);
		this.currentSubnetPage = new CurrentSubnetPage(this.driver);
		this.currentPortPage = new CurrentPortPage(this.driver);
	}

	@Test
	public void addNetworkAddSubnet_DeleteSubnetDeleteNetworkTest() throws InterruptedException {
		this.createNetwork(Login.validUsername, Login.validPassword, Networks.networkName, Networks.physicalName,
				Networks.segmentation, Networks.adminProject, Networks.vlanType);
		this.networksPage.openAddedNetwork();

		createSubnet(Subnet.subnetName, Subnet.subnetAddress);

		this.driver.navigate().refresh();
		this.currentNetworkPage.openAddedSubnet();
		this.currentSubnetPage.deleteAddedSubnet();

		Assert.assertFalse(this.currentNetworkPage.addedSubnetVisible());

		this.projectsPage.openNetworksPage();
		this.networksPage.openAddedNetwork();
		this.currentNetworkPage.deleteNetwork();
		this.driver.navigate().refresh();

		Assert.assertFalse(networksPage.addedNetworksVisible());
	}

	@Test
	public void addNetworkAddSubnet_withoutNetworkAddress_ShowErrorDeleteNetworkTest() throws InterruptedException {
		this.createNetwork(Login.validUsername, Login.validPassword, Networks.networkName, Networks.physicalName,
				Networks.segmentation, Networks.adminProject, Networks.vlanType);
		this.networksPage.openAddedNetwork();
		createSubnet(Subnet.subnetName, "");
		driver.navigate().refresh();

		Assert.assertFalse(this.currentNetworkPage.addedSubnetVisible());

		this.projectsPage.openNetworksPage();
		this.networksPage.openAddedNetwork();
		this.currentNetworkPage.deleteNetwork();
	}

	@Test
	public void addNetworkAddSubnet_smalltNetworkAddress_ShowErrorDeleteNetworkTest() throws InterruptedException {
		this.createNetwork(Login.validUsername, Login.validPassword, Networks.networkName, Networks.physicalName,
				Networks.segmentation, Networks.adminProject, Networks.vlanType);
		this.networksPage.openAddedNetwork();
		createSubnet(Subnet.subnetName, Subnet.smallNetworkAddress);
		driver.navigate().refresh();

		Assert.assertFalse(this.currentNetworkPage.addedSubnetVisible());

		this.projectsPage.openNetworksPage();
		this.networksPage.openAddedNetwork();
		this.currentNetworkPage.deleteNetwork();
	}

	@Test
	public void addNetworkAddSubnetAddPort_DeletePortDeleteNetworkTest() throws InterruptedException {
		this.createNetwork(Login.validUsername, Login.validPassword, Networks.networkName, Networks.physicalName,
				Networks.segmentation, Networks.adminProject, Networks.vlanType);
		this.networksPage.openAddedNetwork();
		createSubnet(Subnet.subnetName, Subnet.subnetAddress);

		this.currentNetworkPage.openPorts();
		this.currentNetworkPage.fillPortForm(Port.portName, Port.specifyIPAddress);
		this.driver.navigate().refresh();

		Assert.assertTrue(this.currentNetworkPage.addedPortVisible());

		this.currentNetworkPage.openAddedPort();
		this.currentPortPage.deleteAddedPort();

		Assert.assertFalse(this.currentNetworkPage.addedPortVisible());

		this.projectsPage.openNetworksPage();
		this.networksPage.openAddedNetwork();
		this.currentNetworkPage.deleteNetwork();
		this.driver.navigate().refresh();

		Assert.assertFalse(networksPage.addedNetworksVisible());
	}

	private void createNetwork(String username, String password, String netName, String phyName, String segmentation,
			String project, String netType) throws InterruptedException {
		this.loginPage.login(username, password);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(netName, phyName, segmentation, project, netType);
		TimeUnit.SECONDS.sleep(1);
		driver.navigate().refresh();
		TimeUnit.SECONDS.sleep(1);
		driver.navigate().refresh();

		Assert.assertTrue(networksPage.addedNetworksVisible());
	}

	private void createSubnet(String subnetName, String subnetAddress) {
		this.currentNetworkPage.openSubnets();
		this.currentNetworkPage.fillSubnetForm(subnetName, subnetAddress);
	}
}
