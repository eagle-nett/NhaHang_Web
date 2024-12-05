
var colorButtons = document.querySelectorAll('.color_ip button');

for (var i = 0; i < colorButtons.length; i++) {
  var button = colorButtons[i];
  
  // Thêm sự kiện click vào từng button
  button.addEventListener('click', function() {
    // Bỏ trạng thái zoom của các button khác
    for (var j = 0; j < colorButtons.length; j++) {
      colorButtons[j].classList.remove('zoomed');
    }
    
    // Thêm trạng thái zoom vào button được click
    this.classList.add('zoomed');
  });
}

// zoom size
var sizeButtons = document.querySelectorAll('.size_ip .size_btn');

for (var i = 0; i < sizeButtons.length; i++) {
  var button = sizeButtons[i];

  // Thêm sự kiện click vào từng button
  button.addEventListener('click', function() {
    // Bỏ trạng thái zoom của các button khác
    for (var j = 0; j < sizeButtons.length; j++) {
      sizeButtons[j].classList.remove('zoomed');
    }

    // Thêm trạng thái zoom vào button được click
    this.classList.add('zoomed');
  });
}

//PHẦN SỐ LƯỢNG
// Lấy phần tử input và nút tương ứng
var inputElement = document.querySelector('.quantity_ip input');
var decreaseBtn = document.querySelector('.quantity_ip .decrease');
var increaseBtn = document.querySelector('.quantity_ip .increase');

// Xử lý sự kiện khi nhấn nút "-"
decreaseBtn.addEventListener('click', function() {
  var currentValue = parseInt(inputElement.value);
  if (currentValue > 1) {
    inputElement.value = currentValue - 1;
  }
});

// Xử lý sự kiện khi nhấn nút "+"
increaseBtn.addEventListener('click', function() {
  var currentValue = parseInt(inputElement.value);
  if (currentValue < 10) {
    inputElement.value = currentValue + 1;
  }
});


// PHẦN NHẢY ẢNH
let mainImg = document.querySelector('.main_img img')
function showImg(pic)
{
    mainImg.src = pic;
}

//ĐÁNH GIÁ
const ratingInputs = document.querySelectorAll('.rating_ip input');

ratingInputs.forEach(input => {
  input.addEventListener('change', () => {
    const currentValue = input.value;
    console.log(`Selected rating: ${currentValue}`);
  });
});



// trái tymm danh mục yêu thích
let icon = document.querySelector('ion-icon');
icon.onclick = function(){
  icon.classList.toggle('active');
}