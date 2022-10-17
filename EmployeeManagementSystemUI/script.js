// GETDATA BY API
let table;
var row;
function getemployees()  
{
    row=' '
    table =   document.querySelector('#employeeData')
    url = 'https://localhost:7258/employee';
    $.get(url , function(data, status){
    console.log(data)
    table.innerHTML=' '
    for(let i=0;i<data.length;i++)
{ 
    row =`<tr>
        <td>${data[i].employeeId}</td>
        <td>${data[i].firstName}</td>
        <td>${data[i].lastName}</td>
        <td>${data[i].emailId}</td>
        <td>${data[i].contact}</td>
        <td>${data[i].address}</td>
        <td>${data[i].salary}</td>
        <td>${data[i].departmentName}</td>
        <td>${data[i].roleName}</td>
        </tr>`
        table.innerHTML +=row;
}
    });
}


function parseJwt (data) 
{
    debugger
    var base64Url = data.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) 
    {
    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

//POSTDATA
console.log
function getData()
{
let email= document.getElementById('typeEmailX').value
let password= document.getElementById('typePasswordX').value
console.log(email,password)
$.post("https://localhost:7162/auth/login", {EmailId: email, Password: password},function(data,status){
    alert("Data: " + data + "\nStatus: " + status);
    console.log(data)
    console.log( parseJwt(data))
});
}