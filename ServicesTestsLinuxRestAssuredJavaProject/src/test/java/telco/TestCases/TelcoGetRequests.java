package telco.TestCases;

import static com.jayway.restassured.RestAssured.given;

import org.testng.Assert;
import org.testng.annotations.Test;

import com.jayway.restassured.path.xml.XmlPath;
import com.jayway.restassured.path.xml.XmlPath.CompatibilityMode;
import com.jayway.restassured.response.Response;

import Data.GetURL;

public class TelcoGetRequests extends BaseTest {

	@Test
	public void getNetworksPage() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getNetworksUrl);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Networks - Telco Systems NFV Orchestration");
	}

	@Test
	public void getNetworksPage_InvalidUrl_ReturnError() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getInvalidNetworksUrl);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 404);
		Assert.assertEquals(responseTitle, " - Page Not Found - Telco Systems NFV Orchestration");
	}

	@Test
	public void getCreateNetworkForm() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getCreateNetworkFormUrl);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Create Network - Telco Systems NFV Orchestration");
	}

	@Test
	public void getCreateNetworkForm_InvalidUrl() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getCreateNetworkFormInvalidUrl);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 404);
		Assert.assertEquals(responseTitle, " - Page Not Found - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenAdminProject() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenAdminProjectURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Project Details - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenNonExistenProjectDetail_OpenProjectsPage() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenProjectNonExistenProjectURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Projects - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenTestNetwork() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenTestNetworkURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "\n  test\n - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenNonExistenNetworkDetail_OpenNetworksPage() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenNonExistenNetworkURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Networks - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenTestNetworkSubnetsForm() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenTestNetworkCreateSubnetFormURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Create Subnet - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenNonExistenNetworkSubnetsForm_OpenNetworksPage() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenTNonExistenNetworkCreateSubnetFormURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Networks - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenTestNetworkPortForm() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenTestNetworkCreatePortFormURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Create Port - Telco Systems NFV Orchestration");
	}
	
	@Test
	public void getOpenNonExistenNetworkPortForm_OpenNetworksPage() {
		Response resp = given().cookie("sessionid", sessionid).when().get(GetURL.getOpenTNonExistenNetworkCreatePortFormURL);

		String responseBody = resp.getBody().asString();
		XmlPath xm = new XmlPath(CompatibilityMode.HTML, responseBody);
		String responseTitle = xm.getString("html.head.title");

		Assert.assertEquals(resp.getStatusCode(), 200);
		Assert.assertEquals(responseTitle, "Networks - Telco Systems NFV Orchestration");
	}
}
