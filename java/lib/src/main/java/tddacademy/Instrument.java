package tddacademy;

public interface Instrument {
    void execute(String task);
    void addEventHandler(InstrumentEventHandler eventHandler);
}