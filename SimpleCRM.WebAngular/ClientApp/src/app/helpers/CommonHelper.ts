export class CommonHelper {

  static removeItemFromArray(array: any, item: any) {
    const index: number = array.indexOf(item);
    if (index !== -1) {
      array.splice(index, 1);
    }
  }

}
