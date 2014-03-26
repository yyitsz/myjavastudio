package com.opensymphony.workflow.dao;

import org.springframework.dao.DataAccessException;
import com.opensymphony.workflow.vo.DocumentationVO;

import java.util.List;

/**
 * @author chris.chen
 */
public interface WorkflowDAO {

    /**
     * ����һ���ĵ�
     *
     * @param wf_id   �������̱��
     * @param title   �ĵ�����
     * @param content �ĵ�����
     * @throws DataAccessException
     */
    void saveDocumentation(long wf_id, String title, String content) ;

    /**
     * ����һ���ĵ�
     *
     * @param wf_id   �������̱��
     * @param title   �ĵ�����
     * @param content �ĵ�����
     * @throws DataAccessException
     */

    void updateDocumentation(long wf_id, String title, String content) ;

    /**
     * ���ݹ������̱�ŷ���һ���ĵ�����
     *
     * @param wf_id �������̱��
     * @return DocumentationVO
     * @throws DataAccessException
     */
    DocumentationVO getDocByWorkflowId(long wf_id) ;

    /**
     * ȡ����Ч����ʵ���б�
     *
     * @return long[] ��Ч����ʵ���б�
     * @throws DataAccessException
     */
    long[] getAvailableWorkflowInstances() ;

    /**
     * ����һ���������
     *
     * @param entry_id  ����ʵ�����
     * @param step_id   ������
     * @param action_id �������
     * @param caller    ������
     * @param opinion   �������
     * @throws DataAccessException
     */
    void saveDocumentationOpinion(long entry_id, int step_id, int action_id, String caller, String opinion);

    /**
     * �õ�ĳһʵ��ĳһ�����������������б�
     *
     * @param entry_id ����ʵ�����
     * @return List ��������б�
     * @throws DataAccessException
     */
    List getDocumentationOpinions(long entry_id) ;
}
