package org.yy.studymina;

import java.util.Date;

import org.apache.mina.core.service.IoHandler;
import org.apache.mina.core.service.IoHandlerAdapter;
import org.apache.mina.core.session.IdleStatus;
import org.apache.mina.core.session.IoSession;

public class TimeServerHandler extends IoHandlerAdapter {

	@Override
	public void exceptionCaught(IoSession session, Throwable cause)
			throws Exception {
		cause.printStackTrace();
	}

	@Override
	public void messageReceived(IoSession session, Object message)
			throws Exception {
		String str=message.toString();
		if(str.trim().equalsIgnoreCase("quit")){
			session.close(true);
			return;
		}
		
		Date date = new Date();
		session.write(date.toString());
		System.out.println("Message written...");
	}

	@Override
	public void sessionIdle(IoSession session, IdleStatus status)
			throws Exception {
		// TODO Auto-generated method stub
		System.out.println("IDLE" + session.getIdleCount(status));
	}

	

}
