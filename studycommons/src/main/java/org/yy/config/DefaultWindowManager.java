package org.yy.config;

public class DefaultWindowManager implements WindowManager {
	private boolean resizable;
	private boolean closable;
	private int defaultWidth;
	private int defaultHeight;
	private WindowStyleDefinition styleDefinition;
	
	public WindowStyleDefinition getStyleDefinition() {
		return styleDefinition;
	}
	public void setStyleDefinition(WindowStyleDefinition styleDefinition) {
		this.styleDefinition = styleDefinition;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#isResizable()
	 */
	public boolean isResizable() {
		return resizable;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#setResizable(boolean)
	 */
	public void setResizable(boolean resizable) {
		this.resizable = resizable;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#isClosable()
	 */
	public boolean isClosable() {
		return closable;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#setClosable(boolean)
	 */
	public void setClosable(boolean closable) {
		this.closable = closable;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#getDefaultWidth()
	 */
	public int getDefaultWidth() {
		return defaultWidth;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#setDefaultWidth(int)
	 */
	public void setDefaultWidth(int defaultWidth) {
		this.defaultWidth = defaultWidth;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#getDefaultHeight()
	 */
	public int getDefaultHeight() {
		return defaultHeight;
	}
	/* (non-Javadoc)
	 * @see org.yy.config.WindowManager#setDefaultHeight(int)
	 */
	public void setDefaultHeight(int defaultHeight) {
		this.defaultHeight = defaultHeight;
	}
	
	
}
