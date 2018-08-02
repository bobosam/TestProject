package telco.TestCases;

import java.util.concurrent.TimeUnit;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import Data.Login;
import Data.Networks;
import telco.Pages.CurrentNetworkPage;
import telco.Pages.LoginPage;
import telco.Pages.NetworksPage;
import telco.Pages.ProjectsPage;

public class NetworksTests extends BaseTest {
	LoginPage loginPage;
	ProjectsPage projectsPage;
	NetworksPage networksPage;
	CurrentNetworkPage currentNetworkPage;
	
	@Before
	public void initializePage() {
		this.initialize();
		this.loginPage = new LoginPage(this.driver);
		this.projectsPage = new ProjectsPage(this.driver);
		this.networksPage = new NetworksPage(this.driver);
		this.currentNetworkPage = new CurrentNetworkPage(this.driver);
	}
	
	@Test	
	public void addNetwork_deleteNetworkTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, Networks.physicalName, Networks.segmentation, Networks.adminProject, Networks.vlanType);
		TimeUnit.SECONDS.sleep(1);
		driver.navigate().refresh();
		TimeUnit.SECONDS.sleep(1);
		driver.navigate().refresh();

		Assert.assertTrue(networksPage.addedNetworksVisible());

		networksPage.openAddedNetwork();
		currentNetworkPage.deleteNetwork();
		driver.navigate().refresh();
		
		Assert.assertFalse(networksPage.addedNetworksVisible());
	}
	
	@Test	
	public void addNetwork_withoutProject_ShowErrorTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, Networks.physicalName, Networks.segmentation, Networks.emptyProject, Networks.vlanType);
		
		Assert.assertTrue(networksPage.requiredElementVisible());
	}
	
	@Test	
	public void addNetwork_withoutPhysicalNetwork_ShowErrorTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, "", Networks.segmentation, Networks.adminProject, Networks.vlanType);
		
		Assert.assertTrue(networksPage.requiredElementVisible());
	}
	
	@Test	
	public void addNetwork_withoutSegmentationId_ShowErrorTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, Networks.physicalName, "", Networks.adminProject, Networks.vlanType);
		
		Assert.assertTrue(networksPage.requiredElementVisible());
	}
	
	@Test	
	public void addNetwork_zeroValueSegmentationId_ShowErrorTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, Networks.physicalName, Networks.zeroSegmentation, Networks.adminProject, Networks.vlanType);
		
		Assert.assertTrue(networksPage.errorSegmentationIDVisible());
	}
	
	@Test	
	public void addNetwork_biggerValueSegmentationId_ShowErrorTest() throws InterruptedException{
		this.loginPage.login(Login.validUsername, Login.validPassword);
		projectsPage.openAdminAccordion();
		projectsPage.openNetworksPage();
		networksPage.openAddNetworkForm();
		networksPage.fillAndSubmitForm(Networks.networkName, Networks.physicalName, Networks.biggerSegmentation, Networks.adminProject, Networks.vlanType);
		
		Assert.assertTrue(networksPage.errorSegmentationIDVisible());
	}
}
