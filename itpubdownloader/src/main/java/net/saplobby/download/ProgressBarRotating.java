package net.saplobby.download;

class ProgressBarRotating extends Thread {

    boolean showProgress = true;

    @Override
    public void run() {
        String anim = "|/-\\";
        int x = 0;
        while (this.showProgress) {
            System.out.print("\r Processing " + anim.charAt(x++ % anim.length()));
            try {
                Thread.sleep(100L);
            } catch (Exception localException) {
            }
        }
    }
}
