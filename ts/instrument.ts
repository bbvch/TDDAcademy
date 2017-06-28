type EventHandler = (task: string) => void;

export interface Instrument {
    execute(task: string): void;
    onEvent(handler: EventHandler): void;
}