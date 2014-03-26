package org.yy.base.dao.dynamic2;

import java.util.HashMap;


    public class ExpressionContext extends HashMap<String,Object>
    {
        /**
		 * 
		 */
		private static final long serialVersionUID = -1339032605205727832L;

		public Object GetValue(String condition)
        {
  
            if(this.containsKey(condition))
            {
                return this.get(condition);
            }
            return null;
        }
    }

