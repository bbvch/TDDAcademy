export interface IBar {
    say: () => string
}

export class Bar implements IBar {
    say() {
        return "bar";
    }
}