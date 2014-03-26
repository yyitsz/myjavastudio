<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles" %>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@taglib uri="http://java.sun.com/jstl/core" prefix="c" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title><tiles:insertAttribute name="title" ignore="true" /></title>
<c:set var="cssUrl"><spring:theme code="css"/></c:set> 
<link rel="stylesheet" href="${pageContext.request.contextPath}/${cssUrl}" type="text/css" />
</head>
<body>
<table border="1" cellpadding="2" cellspacing="2" align="center">
	<tr>
		<td height="30" colspan="2"><tiles:insertAttribute name="header"></tiles:insertAttribute> </td>
	</tr>
	<tr>
		<td height="250"><tiles:insertAttribute name="menu"></tiles:insertAttribute> </td>
		<td width="350"><tiles:insertAttribute name="body"></tiles:insertAttribute> </td>
	</tr>
	<tr>
		<td height="30" colspan="2"><tiles:insertAttribute name="footer"></tiles:insertAttribute> </td>
	</tr>
</table>
</body>
</html>