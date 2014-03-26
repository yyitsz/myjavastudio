<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix = "form" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>


<h1>Login</h1><c:if test="${error != null}"><div id="login-error"><font color="red">${error}</font></div>
	<c:set var="userName" value="${SPRING_SECURITY_LAST_USERNAME}"/>
</c:if>
<form action="<c:url value="/j_spring_security_check" />" method="post">
	<p>
		<label for="j_username">Username</label>
		<input id="j_username" name="j_username" type="text" value="${userName}"/>
		
	</p>
		<p>
		<label for="j_password">Password</label>
		<input id="j_password" name="j_password" type="password" />
		
	</p>
	<p><input type="checkbox" name="_spring_security_remember_me">Don't ask for my password for two weeks.</p>
	<input type="submit" value="Submit" />
</form>
