package org.yy.common.web.auth.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Properties;
import java.util.Set;
import java.util.Map.Entry;

import org.yy.common.util.ExProperties;
import org.yy.common.web.auth.AuthConfig;
import org.yy.common.web.auth.Permission;


/**
 * @author Administrator
 * 
 * @since 2007-9-11
 */
public class PropertiesAuthConfig implements AuthConfig{

	AuthConfigBean bean;
	/**
	 * 
	 */
	public PropertiesAuthConfig(String resource) {
		Properties prop = ExProperties.loadFromClassPath(resource, "utf-8");
		bean = new AuthConfigBean();
		bean.setDeniedPage("/denied");
		bean.addIgnorePage("/");
		bean.addIgnorePage("/verify");
		bean.addIgnorePage("/setLocale");
		bean.addIgnorePage("/resources/*");
		bean.setLoginPage("/login");
		bean.setDeniedPage(prop.getProperty("page.denied"));
		String ignore = prop.getProperty("page.ignores");
		if(ignore!=null && ignore.length()!=0){
			String[] ignores = ignore.split(";");
			List<String> l = new ArrayList<String>();
			for(int i=0;i<ignores.length;i++){
				l.add(ignores[i]);
			}
			bean.setIgnorePages(l);
		}
		bean.setLoginPage(prop.getProperty("page.login"));
		//permission map
		Map<String, Permission> pm = new HashMap<String, Permission>();
		Set<Entry<Object,Object>> entrySet = prop.entrySet();
		for(Entry<Object, Object> e : entrySet){
			String k = (String) e.getKey();
			if(k.matches("auth\\..*")){
				k= k.substring(5);
				String v= (String) e.getValue();
				String[] urls = v.split(";");
				List<String> listUrl = new ArrayList<String>();
				for(int i=0;i<urls.length;i++){
					listUrl.add(urls[i]);
				}
				PermissionBean p = new PermissionBean();
				p.setKey(k);
				p.setUrls(listUrl);
				pm.put(k, p	);
			}
		}
		bean.setPermissionMap(pm);
	}
	
	public String getDeniedPage() {
		return bean.getDeniedPage();
	}

	public String getLoginPage() {
		return bean.getLoginPage();
	}

	public Map<String, Permission> getPermissionMap() {
		return bean.getPermissionMap();
	}

	public boolean isIgnore(String servletPath) {
		return bean.isIgnore(servletPath);
	}

}
