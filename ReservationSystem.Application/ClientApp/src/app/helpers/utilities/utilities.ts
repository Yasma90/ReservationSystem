//import { UUID } from "angular2-uuid";
//import { Guid } from "guid-typescript";

export function errorsResponseApi(respose: any): string[] {
  const result: string[] = []

  if(respose.error) {
    if(typeof respose.error == 'string') {
      result.push(respose.error);
    }
    else {
      const mapErrors = respose.error.errors;
      const inputs = Object.entries(mapErrors);

      inputs.forEach((arr: any[]) => {
        const field = arr[0];
        arr[1].forEach((messageErr: any) => {
          result.push(`${field}: ${messageErr}`);
        });
      });
    }
  }
  return result;

}


export function generateGuid(): void {
   //UUID.UUID();
  //return Guid.create().toString();
}
