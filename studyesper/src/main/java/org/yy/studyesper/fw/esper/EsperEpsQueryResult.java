package org.yy.studyesper.fw.esper;

import java.util.Iterator;

import org.yy.studyesper.fw.EpsEventBean;
import org.yy.studyesper.fw.EpsQueryResult;

import com.espertech.esper.client.EPOnDemandQueryResult;
import com.espertech.esper.client.EventBean;

public class EsperEpsQueryResult implements EpsQueryResult {

	private class EsperEpsQueryResultIterator implements Iterator<EpsEventBean> {

		private Iterator<EventBean> iterator;

		public EsperEpsQueryResultIterator(Iterator<EventBean> iterator) {
			this.iterator = iterator;
		}

		@Override
		public boolean hasNext() {
			return iterator.hasNext();
		}

		@Override
		public EpsEventBean next() {
			return EsperHelper.wrap(iterator.next());
		}

		@Override
		public void remove() {
			iterator.remove();

		}
	}

	EPOnDemandQueryResult result;

	public EsperEpsQueryResult(EPOnDemandQueryResult result) {
		this.result = result;
	}

	@Override
	public EpsEventBean[] getArray() {
		return EsperHelper.wrap(result.getArray());
	}

	@Override
	public Iterator<EpsEventBean> iterator() {

		return new EsperEpsQueryResultIterator(result.iterator());
	}

}
