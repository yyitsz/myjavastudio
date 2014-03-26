<%@taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<h2>Contact Manager</h2>
<form:form method="post" action="add.html" commandName="contact">
	<table>
		<tr>
			<td><form:label path="firstName"><spring:message code="label.firstname" /></form:label></td>
			<td><form:input path="firstName" ></form:input></td>
		</tr>
		<tr>
			<td><form:label path="lastName"><spring:message code="label.lastname" /></form:label></td>
			<td><form:input path="lastName" ></form:input></td>
		</tr>
		<tr>
			<td><form:label path="email"><spring:message code="label.email" /></form:label></td>
			<td><form:input path="email" ></form:input></td>
		</tr>
		<tr>
			<td><form:label path="telephone"><spring:message code="label.telephone" /></form:label></td>
			<td><form:input path="telephone" ></form:input></td>
		</tr>
		<tr>
			<td colspan="2"><input type="submit" value="<spring:message code="label.addcontact" />"></input></td>
		</tr>
	</table>
</form:form>

<h2>Contacts</h2>
<c:if test="${!empty contactList}">
	<table class="data">
		<tr>
			<th>Name</th>
			<th>Email</th>
			<th>Telephone</th>
			<th>&nbsp;</th>
		</tr>
		<c:forEach items="${contactList}" var="contact">
			<tr>
				<td>${contact.lastName}, ${contact.firstName }
				</td>
				<td>${contact.email }</td>
				<td>${contact.telephone }</td>
				<td><a href="delete/${contact.id }.html">Delete</a></td>
			</tr>
		</c:forEach>
	</table>
</c:if>