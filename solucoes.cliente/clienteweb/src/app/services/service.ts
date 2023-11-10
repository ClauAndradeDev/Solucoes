import { environment } from "src/environment";

export abstract class Service {
  private readonly baseUrl = environment['endpoint'];
  protected abstract controllerName: string;

  get controllerUrl() : string {
    return `${this.baseUrl}/${this.controllerName}`;
  }
}
