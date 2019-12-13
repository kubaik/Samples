package org.camunda.bpm.getstarted.cmmn.loanapproval;

import java.util.logging.Logger;

import org.camunda.bpm.engine.delegate.CaseExecutionListener;
import org.camunda.bpm.engine.delegate.DelegateCaseExecution;

public class LifecycleListener implements CaseExecutionListener {

    private final static Logger LOGGER = Logger.getLogger("LOAN-REQUESTS-CMMN");

    public void notify(DelegateCaseExecution caseExecution) throws Exception {
        LOGGER.info("Plan Item '" + caseExecution.getActivityId() + "' labeled '"
                + caseExecution.getActivityName() + "' has performed transition: "
                + caseExecution.getEventName());
    }

}