package com.opensymphony.workflow.service;

import com.opensymphony.workflow.Workflow;
import com.opensymphony.workflow.vo.DocumentationVO;
import org.springframework.dao.DataAccessException;

import java.util.List;

/**
 * @author chris.chen
 */
public interface WorkflowService {


    /**
     * ��ʼ��һ��������
     *
     * @param un      ��ǰ�û�
     * @param title   �ĵ�����
     * @param content �ĵ�����
     * @return ��ǰ���������
     * @throws Exception
     */
    public long doInitialize(String un, String title, String content) throws Exception;

    /**
     * ִ�ж���
     *
     * @param wf        Workflow
     * @param wf_id     �������̱��
     * @param step_id   ������
     * @param action_id �������
     * @param un        ��ǰ������
     * @param title     �ĵ�����
     * @param content   �ĵ�����
     * @param opinion   �ĵ��������
     * @throws Exception
     */
    public void doAction(Workflow wf, long wf_id, int step_id, int action_id, String un, String title, String content, String opinion)throws Exception;

    /**
     * ���ݹ������̱�ŷ���һ���ĵ�����
     *
     * @param wf_id �������̱��
     * @return DocumentationVO
     * @throws org.springframework.dao.DataAccessException
     *
     */
    DocumentationVO getDocByWorkflowId(long wf_id);

    /**
     * ȡ����Ч����ʵ���б�
     *
     * @return long[] ��Ч����ʵ���б�
     * @throws DataAccessException
     */
    long[] getAvailableWorkflowInstances();

    /**
     * �õ�ĳһʵ��ĳһ�����������������б�
     *
     * @param entry_id ����ʵ�����
     * @return List ��������б�
     * @throws DataAccessException
     */
    List getDocumentationOpinions(long entry_id);
}
