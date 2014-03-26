<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="s"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Confuscation</title>
</head>
<body>
Message: ${message }
<spring:form action="executeObfuscation.html" method="post" commandName="profile">
	Source Folder:<spring:input path="sourceFolder"/><br />
	<br />
	Ddestincation Folder:<spring:input path="destincationFolder"/><br />
	
	<br />
	Assemblies:
	<spring:checkboxes items="${assemblies}" path="assemblyList" />
	<br />
	<input type="submit" value="submit" />
	"
</spring:form>
</body>
</html>