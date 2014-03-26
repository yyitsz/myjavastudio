/*
 * Copyright 2002-2007 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package org.yy.common.resource;

public class FileSystemResourceLoader extends AbstractResourceLoader {

private String prefix;
	
	public FileSystemResourceLoader() {
		this("");
	}
	
	public FileSystemResourceLoader(String prefix) {
		super();
		if(prefix.startsWith("/"))
			prefix = prefix.substring(1);
		if(!prefix.endsWith("/"))
			prefix = prefix + "/";
		this.prefix = prefix;
	}

	public Resource getResource(String location) {
		if(location.startsWith("/"))
			location = location.substring(1);
		return new FileSystemResource(prefix+location);
	}
//	
//	public Resource getResource(String location) {
//		return new FileSystemResource(location);
//	}

}
