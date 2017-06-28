package tddacademy;

public interface InstrumentEventHandler {
    void handleFinished(String task);
    void handleError(String task);
}
