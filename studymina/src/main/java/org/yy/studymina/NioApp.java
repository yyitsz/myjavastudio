package org.yy.studymina;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.channels.SocketChannel;

public class NioApp {
	public static void main(String[] args) throws Exception {

		// readFile();
		readWeb();
	}

	private static void readWeb() throws Exception {

		SocketChannel channel;
		try {
			channel = SocketChannel.open();
			channel.configureBlocking(false);
			channel.connect(new InetSocketAddress("http://www.sina.com.cn/", 80));
			while(!channel.finishConnect()){
				Thread.sleep(100);
			}
			ByteBuffer buf = ByteBuffer.allocate(1024);
			long bytesRead = channel.read(buf);
			while (bytesRead != -1) {

				buf.flip();
				while (buf.hasRemaining()) {
					System.out.print((char) buf.get());
				}
				buf.clear();
				bytesRead = channel.read(buf);
			}
			channel.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private static void readFile() throws FileNotFoundException, IOException {
		RandomAccessFile afile = new RandomAccessFile("src/data/test.txt", "rw");
		FileChannel inChannel = afile.getChannel();
		ByteBuffer buf = ByteBuffer.allocate(48);
		long bytesRead = inChannel.read(buf);
		while (bytesRead != -1) {

			buf.flip();
			while (buf.hasRemaining()) {
				System.out.print((char) buf.get());
			}
			buf.clear();
			bytesRead = inChannel.read(buf);
		}
		buf.clear();
		buf.put((byte) 'H');
		buf.put((byte) 'H');
		buf.put((byte) 'H');
		buf.put((byte) 'H');
		buf.put((byte) 'H');
		buf.put((byte) 'H');

		buf.flip();
		inChannel.write(buf);
		afile.close();
	}
}
