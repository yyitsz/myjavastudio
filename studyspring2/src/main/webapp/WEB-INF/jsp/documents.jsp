<%@taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<h2>Document Manager</h2>
<h3>Add new document</h3>

<form:form method="post" action="save.html" commandName="document" enctype="multipart/form-data">
	<form:errors path="*" cssClass="error" />
	<table>
		<tr>
			<td><form:label path="name">Name</form:label></td>
			<td><form:input path="name"></form:input></td>
		</tr>
		<tr>
			<td><form:label path="description">Description</form:label></td>
			<td><form:textarea path="description"></form:textarea></td>
		</tr>
		<tr>
			<td><form:label path="content">Document</form:label></td>
			<td><input type="file" name="file" id="file" /></td>
		</tr>
		<tr>
	
			<td colspan="2"><input type="submit" value="Add Document" /></td>
		</tr>
	</table>
</form:form>

<br />
<h3>Document List</h3>
<c:if test="${!empty documentList}">
	<table class="data">
		<tr>
			<th width="100px">Name</th>
			<th  width="250px">Description</th>
			<th width="20px"></th>
		</tr>
		<c:forEach items="${documentList}" var="document">
		<tr>
			<td>${document.name}</td>
			<td>${document.description }</td>
			<td><a href="<c:url value="/doc/download/${document.id}.html" />" title="Download this document">Download</a>
			<a href="<c:url value="/doc/delete/${document.id}.html"  />"
			onclick="return confirm('Are you sure to delete this document?')"
			title="Download this document">Delete</a>
			</td>
		</tr>
		</c:forEach>
	</table>
</c:if>