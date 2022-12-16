/*/*Created By Er. Pramod kumar Behera*/
//this is the dropdown validation 
//its check its value is zero or not
//by using key "onchange="dropDownValidation('id')"" inside dropdown controller
//also check it on if(dropDownValidation('drpState')==true(){}
function dropDownValidation(id) {
  
    var x = $("#" + id).val();
   // alert(x);
    if (x == 0 || x==null) {
        $("#" + id).css("background-color", "red");
        return false;
    } else {
        $("#" + id).css("background-color", "");
        return true;
    }
}