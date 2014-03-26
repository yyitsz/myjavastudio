package net.saplobby.download;

class ProgressBarTraditional extends Thread {

    boolean showProgress = true;

    @Override
    public void run() {
        String anim = "=====================";
        int x = 0;
        while (this.showProgress) {
            System.out.print("\r Processing "
                    + anim.substring(0, x++ % anim.length())
                    + " ");
            try {
                Thread.sleep(100L);
            } catch (Exception localException) {
            }
        }
    }
}
