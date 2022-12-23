const btnAdd = document.querySelector('.btnOpen');
const btnClose = document.querySelector('.btnClose');
function AddItem()
{
    btnAdd.addEventListener('click', () => {
        document.querySelectorAll('#newBlock').forEach(item => {
            item.classList.remove('display-none')
        });
    });
}
function CloseItem()
{
    btnClose.addEventListener('click', () => {
        document.querySelectorAll('#newBlock').forEach(item => {
            item.classList.add('display-none')
        });
    });
}
AddItem();
CloseItem();