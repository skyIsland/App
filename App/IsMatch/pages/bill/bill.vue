<template>
	<view>
		<view class="uni-padding-wrap uni-common-mt">
			<view>
				<scroll-view class="list" scroll-y>
					<uni-list>
						<uni-list-item  v-bind:title="item.summary"  v-for="item in billList" :key="item.id" 
								show-badge="true"  v-bind:note="item.typeStr" 
								v-bind:badge-text="item.money"
								@click="showDetail(item)"></uni-list-item>
					</uni-list>
				</scroll-view>
			</view>
		</view>
	</view>
</template>
<script>
	import uniList from '@/components/uni-list/uni-list.vue'
	import uniListItem from '@/components/uni-list-item/uni-list-item.vue'

	export default {
		components: {
			uniList,
			uniListItem
		},
		data() {
			return {
				// 				loadingText: {
				// 					contentdown: '上拉加载更多',
				// 					contentrefresh: '正在加载...',
				// 					contentnomore: '没有更多数据了'
				// 				},
				// 				refreshing: false,
				// 				refreshText: '下拉可以刷新',
				billList: [{
					typeStr: '支出',
					money: '6',
					summary: '烤奶',
					updateTime:'2019-03-18 22:00'
				}]
			}
		},
		onLoad: function() {
			this.getList();
		},
		methods: {
			getList() {
				uni.showLoading({
					title: '加载中'
				});
				uni.request({
					url: 'http://192.168.1.5:5000/api/bill/getlist',
					success: (result) => {
						if (result.statusCode == 200) {
							console.log(JSON.stringify(result));
							if (result.data.status == 1) {
								this.billList = this.billList.concat(result.data.data);
							}
						} else {
							console.log(JSON.stringify(`${statusCode}{result}`));
						}
					},
					fail: (ret) => {
						uni.showModal({
							title: '提示',
							content: JSON.stringify(ret)
						});
					},
					complete: () => {
						uni.hideLoading();
					}
				})
			},
			showDetail(detail){
				let msg = `${detail.updateTime} ${detail.typeStr} ${detail.summary} ${detail.money}`;
				uni.showModal({
					title: '详细',
					content: msg
				});
			}
		}
	}
</script>

<style>

</style>
