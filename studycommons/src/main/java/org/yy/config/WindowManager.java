package org.yy.config;

public interface WindowManager {

	public abstract boolean isResizable();

	public abstract void setResizable(boolean resizable);

	public abstract boolean isClosable();

	public abstract void setClosable(boolean closable);

	public abstract int getDefaultWidth();

	public abstract void setDefaultWidth(int defaultWidth);

	public abstract int getDefaultHeight();

	public abstract void setDefaultHeight(int defaultHeight);
	public WindowStyleDefinition getStyleDefinition() ;
	public void setStyleDefinition(WindowStyleDefinition styleDefinition);
}