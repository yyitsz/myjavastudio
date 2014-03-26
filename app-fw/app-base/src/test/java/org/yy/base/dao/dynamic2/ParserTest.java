/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package org.yy.base.dao.dynamic2;

import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Ignore;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * 
 * @author yyi
 */
public class ParserTest {

	public ParserTest() {
	}

	@BeforeClass
	public static void setUpClass() throws Exception {
	}

	@AfterClass
	public static void tearDownClass() throws Exception {
	}

	@Test
	@Ignore
	public void testParse() {
		System.out.println("parse");
		String where = "SELECT * FROM person @where {@and{@if(a>0){ C LIKE :C } , {A like :A } , @or{{lastName = :lastName}, {firstName = :firstName} , {B = :B}}}}";
		Parser instance = new Parser(where);

		Expression result = instance.Parse();
		assertNotNull(result);
		System.out.println(result.toString());
		assertNotNull(result);
		System.out.println(result.Eval(new ExpressionContext()));

	}

	@Test
	
	public void testParse2() {
		System.out.println("parse");
		String where = "SELECT * FROM person @where{@and{{ p.id exists (select id from user @where { @and{ @if(a>0){ C LIKE :C } , {A like :A} ,@or {{lastName = :lastName}, {firstName = :firstName} , {B = :B}}}}}}} group by a.bcd order by c desc";
		Parser instance = new Parser(where);

		Expression result = instance.Parse();
		assertNotNull(result);
		System.out.println(result.Eval(new ExpressionContext()));
		// LogicExpression lexp = (LogicExpression) result;
		// assertNotNull( lexp);
		// assertEquals(3, lexp.getExpressions().size());

	}

}