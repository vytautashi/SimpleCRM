export class CommonHelper {

  static removeItemFromArray(array: any, item: any) {
    const index: number = array.indexOf(item);
    if (index !== -1) {
      array.splice(index, 1);
    }
  }

  static formatMyDate(dateTime: Date) {
    let date: Date = new Date(dateTime);
    let day = date.getDate();
    let monthIndex = date.getMonth();
    let year = date.getFullYear();
    let formattedDate = year + "-" + (monthIndex + 1) + "-" + day;

    return formattedDate;
  }

}
