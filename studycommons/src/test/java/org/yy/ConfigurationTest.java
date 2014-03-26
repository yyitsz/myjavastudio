package org.yy;

import java.awt.Dimension;
import java.util.Collection;
import java.util.List;
import java.util.Properties;

import junit.framework.Assert;

import org.apache.commons.configuration.Configuration;
import org.apache.commons.configuration.ConfigurationException;
import org.apache.commons.configuration.PropertiesConfiguration;
import org.apache.commons.configuration.XMLConfiguration;
import org.apache.commons.configuration.beanutils.BeanDeclaration;
import org.apache.commons.configuration.beanutils.BeanHelper;
import org.apache.commons.configuration.beanutils.XMLBeanDeclaration;
import org.junit.Test;
import org.yy.config.WindowManager;

/**
 * Unit test for simple App.
 */
public class ConfigurationTest {
	@Test
	public void TestConfiguration() throws ConfigurationException {
		PropertiesConfiguration config = new PropertiesConfiguration(
				"gui.properties");
		String backColor = config.getString("colors.background");
		Dimension size = new Dimension(config.getInt("window.width"), config
				.getInt("window.height"));

		Assert.assertEquals("#FFFFFF", backColor);
		Assert.assertEquals(500, size.width);
		Assert.assertEquals(300, size.height);

		String[] colors = config.getStringArray("colors.pie");
		List colorList = config.getList("colors.pie");

		Properties p = config.getProperties("colors.kv");
		System.out.println(p);

		Configuration subConfig = config.subset("window");
		int width = subConfig.getInt("width");

		Assert.assertEquals(500, width);
	}

	@SuppressWarnings("unchecked")
	@Test
	public void TestXmlConfiguration() throws ConfigurationException {
		XMLConfiguration config = new XMLConfiguration("gui.xml");
		String backColor = config.getString("colors.background");
		String textColor = config.getString("colors.text");
		String linkNormal = config.getString("colors.link[@normal]");
		String defColor = config.getString("colors.default");
		int rowsPerPage = config.getInt("rowsPerPage");
		List buttons = config.getList("buttons.name");
		
		Object ips = config.getProperty("brokers.server.ip");
		if(ips instanceof Collection){
			System.out.println( ((Collection<String>)ips).toArray());
		}
		

	}


	@Test
	public void TestBeanXmlConfiguration() throws ConfigurationException {
		XMLConfiguration config = new XMLConfiguration("gui.xml");
		
		BeanDeclaration decl = new XMLBeanDeclaration(config,"gui.windowManager");
		WindowManager wm = (WindowManager) BeanHelper.createBean(decl);
		Assert.assertNotNull(wm);
		Assert.assertNotNull(wm.getStyleDefinition());
		Assert.assertEquals(400, wm.getDefaultWidth());
		Assert.assertEquals(false, wm.isClosable());
	   Assert.assertEquals("myicon",wm.getStyleDefinition().getIconName());
	}
}
