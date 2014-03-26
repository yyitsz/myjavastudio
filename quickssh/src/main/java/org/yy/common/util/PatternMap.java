/**
 * Light-commons Project
 * http://light-commons.googlecode.com
 * Copyright (C) 2008 Jason Green
 * email: guileen@gmail.com
 *
 * License: Apache License 2.0 
 * (http://www.apache.org/licenses/LICENSE-2.0)
 *
 */
package org.yy.common.util;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author gl
 * @since Jun 30, 2008
 */
public class PatternMap<T> {
	private LinkedHashMap<Pattern, T> m=new LinkedHashMap<Pattern, T>();
	
	public void put(Pattern pattern,T value ){
		m.put(pattern, value);
	}
	
	public void put(String regex,T value){
		put(Pattern.compile(regex), value);
	}
	
	public T get(String test){
		for(Map.Entry<Pattern, T> e:m.entrySet()){
			Matcher matcher = e.getKey().matcher(test);
			if(matcher.matches()){
				return e.getValue();
			}
		}
		return null;
	}
	
	public MatchedResult<T> matcher(String test){
		for(Map.Entry<Pattern, T> e:m.entrySet()){
			Matcher matcher = e.getKey().matcher(test);
			if(matcher.matches()){
				return new MatchedResult<T>(matcher,e.getValue());
			}
		}
		return null;
	}
	
	public List<MatchedResult<T>> allMatcher(String test){
		List<MatchedResult<T>> results = new ArrayList<MatchedResult<T>>();
		for(Map.Entry<Pattern, T> e:m.entrySet()){
			Matcher matcher = e.getKey().matcher(test);
			if(matcher.matches()){
				results.add(new MatchedResult<T>(matcher,e.getValue()));
			}
		}
		return results;
	}
	
	public List<T> getAll(String test){
		List<T> results = new ArrayList<T>();
		for(Map.Entry<Pattern, T> e:m.entrySet()){
			Matcher matcher = e.getKey().matcher(test);
			if(matcher.matches()){
				results.add(e.getValue());
			}
		}
		return results;
	}
	
	public static class MatchedResult<T>{
		private Matcher matcher;
		private T result;
		
		/**
		 * @param matcher
		 * @param result
		 */
		public MatchedResult(Matcher matcher, T result) {
			super();
			this.matcher = matcher;
			this.result = result;
		}
		public Matcher getMatcher() {
			return matcher;
		}
		public T getResult() {
			return result;
		}
		
	}
}
