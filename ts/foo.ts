import { IBar } from "./bar";

export class Foo {
  constructor(private bar: IBar) {}

  say() {
    return "foo" + this.bar.say();
  }
}
