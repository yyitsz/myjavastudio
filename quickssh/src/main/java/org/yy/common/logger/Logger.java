package org.yy.common.logger;

/**
 * Use to migrate Log4j code.
 * @author gl
 *
 */
public class Logger implements Log{
	private final Log log;
	private Logger(Log log){
		this.log=log;
	}
	
	public static Logger getLogger(String name){
		return new Logger(LogFactory.getLog(name));
	}
	
	public static Logger getLogger(Class clz){
		return new Logger(LogFactory.getLog(clz));
	}
	
	public void debug(Object message) {
		log.debug(message);
	}
	public void debug(Object message, Throwable throwable) {
		log.debug(message, throwable);
	}
	public void error(Object message) {
		log.error(message);
	}
	public void error(Object message, Throwable throwable) {
		log.error(message, throwable);
	}
	public void fatal(Object message) {
		log.fatal(message);
	}
	public void fatal(Object message, Throwable throwable) {
		log.fatal(message);
	}
	public void info(Object message) {
		log.info(message);
	}
	public void info(Object message, Throwable throwable) {
		log.info(message, throwable);
	}
	public boolean isDebugEnabled() {
		return log.isDebugEnabled();
	}
	public boolean isErrorEnabled() {
		return log.isErrorEnabled();
	}
	public boolean isFatalEnabled() {
		return log.isFatalEnabled()	;
	}
	public boolean isInfoEnabled() {
		return log.isInfoEnabled();
	}
	public boolean isTraceEnabled() {
		return log.isTraceEnabled();
	}
	public boolean isWarnEnabled() {
		return log.isWarnEnabled();
	}
	public void trace(Object message) {
		log.trace(message);
	}
	public void trace(Object message, Throwable throwable) {
		log.trace(message, throwable);
	}
	public void warn(Object message) {
		log.warn(message);
	}
	public void warn(Object message, Throwable throwable) {
		log.warn(message, throwable);
	}
	
}
