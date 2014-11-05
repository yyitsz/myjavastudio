/*
 * Copyright (C) 2010 Roland Bali
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

package se.spagettikod.optimist.impl.mapper;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import se.spagettikod.optimist.LockedByAnotherUserException;
import se.spagettikod.optimist.impl.EntityWrapper;

import com.mysql.jdbc.exceptions.jdbc4.MySQLTransactionRollbackException;

/**
 * @author Roland Bali
 * 
 */
public class MySqlMapper implements Mapper {

	@Override
	public Object getCurrentEntityVersionInDatabase(Connection connection,
			EntityWrapper entityWrapper) throws SQLException {
		PreparedStatement stmt = null;
		try {
			stmt = connection
					.prepareStatement("SELECT "
							+ entityWrapper.getVersionColumnName() + " FROM "
							+ entityWrapper.getTableName()
							+ " WHERE id = ? FOR UPDATE");
			stmt.setObject(1, entityWrapper.getIdentity());
			stmt.execute();
			ResultSet rs = stmt.getResultSet();
			if (rs.first()) {
				Object databaseVersion = rs.getObject(1);
				rs.close();
				return databaseVersion;
			} else {
				return null;
			}
		} catch (MySQLTransactionRollbackException e) {
			throw new LockedByAnotherUserException();
		} finally {
			if (stmt != null && !stmt.isClosed()) {
				stmt.close();
			}
		}
	}

	@Override
	public boolean isCompatible(Connection connection) {
		return false;
	}

}
