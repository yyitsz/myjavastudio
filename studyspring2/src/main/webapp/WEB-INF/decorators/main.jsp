<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://www.opensymphony.com/sitemesh/decorator" prefix="decorator" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<decorator:head ></decorator:head>
</head>
<body>
<h1><decorator:title default="welcome" /></h1>
	<p><decorator:body /></p>
	<p><samll>(<a href="?printable=true">printable version</a>)</samll></p>
</body>
</html>