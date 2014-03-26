<%@taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@taglib uri="http://java.sun.com/jstl/core" prefix="c" %>
<h3><spring:message code="label.title" /></h3>
<span style="float:right">
	<a href="?lang=en">en</a>
	|
	<a href="?lang=cn">cn</a>
</span>


<span style="float:left">
	<a href="?theme=default">Default</a>
	|
	<a href="?theme=black">Black</a>
	|
	<a href="?theme=blue">Blue</a>

</span>
	<br />
	<a href="<c:url value="/auth/logout.html"/>">Logout</a> <span>:</span>
	<a href="<c:url value="/auth/login.html"/>">Login</a>