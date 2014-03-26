package org.yy.studymybatis.util;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public final class Utils {
	private static Logger logger = LoggerFactory.getLogger(Utils.class);

	@SuppressWarnings("unchecked")
	public static <T extends Serializable> T deepCopy(T source) {
		if (source == null) {
			return null;
		}
		ObjectOutputStream objOutput = null;
		ObjectInputStream objInput = null;
		T target = null;
		try {
			ByteArrayOutputStream outStream = new ByteArrayOutputStream();
			objOutput = new ObjectOutputStream(outStream);
			objOutput.writeObject(source);
			objOutput.flush();
			objInput = new ObjectInputStream(new ByteArrayInputStream(outStream
					.toByteArray()));
			target = (T) objInput.readObject();

		} catch (Exception e) {
			throw new RuntimeException("Exception when clone object", e);
		} finally {
			if (objOutput != null) {
				try {
					objOutput.close();
				} catch (IOException e) {
					logger.error("Error when closing ObjectOutputStream", e);
				}
			}

			if (objInput != null) {
				try {
					objInput.close();
				} catch (IOException e) {
					logger.error("Error when closing ObjectInputStream", e);
				}
			}
		}

		return target;
	}
}
