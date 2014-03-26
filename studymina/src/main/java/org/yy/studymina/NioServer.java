package org.yy.studymina;

import java.io.IOException;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;
import java.nio.channels.spi.SelectorProvider;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

public class NioServer implements Runnable {
	private InetAddress hostAddress;
	private int port;
	private ServerSocketChannel serverChannel;
	private Selector selector;
	private ByteBuffer readBuffer = ByteBuffer.allocate(8192);
	private EchoWorker worker;

	private List<ChangeRequest> changeRequests = new LinkedList<ChangeRequest>();

	private Map<SocketChannel, List<ByteBuffer>> pendingData = new HashMap<SocketChannel, List<ByteBuffer>>();

	public NioServer(InetAddress hostAddress, int port, EchoWorker worker)
			throws IOException {
		this.hostAddress = hostAddress;
		this.port = port;
		this.selector = this.initSelector();
		this.worker = worker;
	}

	private Selector initSelector() throws IOException {
		Selector socketSelector = SelectorProvider.provider().openSelector();
		this.serverChannel = ServerSocketChannel.open();
		serverChannel.configureBlocking(false);
		InetSocketAddress isa = new InetSocketAddress(this.hostAddress,
				this.port);
		serverChannel.socket().bind(isa);
		serverChannel.register(socketSelector, SelectionKey.OP_ACCEPT);
		return socketSelector;
	}

	public void run() {
		while (true) {
			try {

				synchronized (this.changeRequests) {
					for (ChangeRequest change : this.changeRequests) {
						switch (change.type) {
						case ChangeRequest.CHANGEOPS:
							SelectionKey key = change.socket
									.keyFor(this.selector);
							key.interestOps(change.ops);
						}
					}
					this.changeRequests.clear();
				}

				this.selector.select();
				Iterator<SelectionKey> selectedKeys = this.selector
						.selectedKeys().iterator();
				while (selectedKeys.hasNext()) {
					SelectionKey key = selectedKeys.next();
					selectedKeys.remove();
					if (key.isValid() == false) {
						continue;
					}
					if (key.isAcceptable()) {
						this.accept(key);
					} else if (key.isReadable()) {
						this.read(key);
					} else if (key.isWritable()){
						this.write(key);
					}
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

	}

	private void write(SelectionKey key) throws IOException {
		SocketChannel socketChannel = (SocketChannel) key.channel();
		synchronized(this.pendingData){
			List<ByteBuffer> queue = this.pendingData.get(socketChannel);
			while(queue.isEmpty() == false){
				ByteBuffer buf = queue.get(0);
				socketChannel.write(buf);
				if(buf.remaining() > 0){
					break;
				}
				queue.remove(0);
			}
			if(queue.isEmpty()){
				key.interestOps(SelectionKey.OP_READ);
			}
		}
		
	}

	private void read(SelectionKey key) throws IOException {
		SocketChannel socketChannel = (SocketChannel) key.channel();
		this.readBuffer.clear();
		int numRead;
		try {
			numRead = socketChannel.read(this.readBuffer);
		} catch (IOException e) {
			key.cancel();
			socketChannel.close();
			e.printStackTrace();
			return;
		}
		if (numRead == -1) {
			key.channel().close();
			key.cancel();
			return;
		}
		this.worker.processData(this, socketChannel, this.readBuffer.array(),
				numRead);
	}

	private void accept(SelectionKey key) throws IOException {
		ServerSocketChannel serverSocketChannel = (ServerSocketChannel) key
				.channel();
		SocketChannel socketChannel = serverSocketChannel.accept();
		Socket socket = socketChannel.socket();
		socketChannel.configureBlocking(false);
		socketChannel.register(this.selector, SelectionKey.OP_READ);
	}

	public void send(SocketChannel socket, byte[] data) {
		synchronized (this.changeRequests) {
			this.changeRequests.add(new ChangeRequest(socket,
					ChangeRequest.CHANGEOPS, SelectionKey.OP_WRITE));
			synchronized (this.pendingData) {
				List<ByteBuffer> queue = this.pendingData.get(socket);
				if (queue == null) {
					queue = new ArrayList<ByteBuffer>();
					this.pendingData.put(socket, queue);

				}
				queue.add(ByteBuffer.wrap(data));
			}
		}
		this.selector.wakeup();
	}

	public static void main(String[] args) {
		try {
			EchoWorker worker = new EchoWorker();
			new Thread(worker).start();
			new Thread(new NioServer(null, 9090, worker)).start();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
