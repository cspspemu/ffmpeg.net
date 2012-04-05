using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public partial class AVPacket
	{

		/* packet functions */

		/**
		 * @deprecated use NULL instead
		 */
		//attribute_deprecated void av_destruct_packet_nofree(AVPacket *pkt);

		/**
		 * Default packet destructor.
		 */
		static public void av_destruct_packet(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Initialize optional fields of a packet with default values.
		 *
		 * @param pkt packet
		 */
		static public void av_init_packet(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Allocate the payload of a packet and initialize its fields with
		 * default values.
		 *
		 * @param pkt packet
		 * @param size wanted payload size
		 * @return 0 if OK, AVERROR_xxx otherwise
		 */
		static public int av_new_packet(AVPacket pkt, int size)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Reduce packet size, correctly zeroing padding
		 *
		 * @param pkt packet
		 * @param size new size
		 */
		static public void av_shrink_packet(AVPacket pkt, int size)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Increase packet size, correctly zeroing padding
		 *
		 * @param pkt packet
		 * @param grow_by number of bytes by which to increase the size of the packet
		 */
		static public int av_grow_packet(AVPacket pkt, int grow_by)
		{
			throw(new NotImplementedException());
		}

		/**
		 * @warning This is a hack - the packet memory allocation stuff is broken. The
		 * packet is allocated if it was not really allocated.
		 */
		static public int av_dup_packet(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Free a packet.
		 *
		 * @param pkt packet to free
		 */
		static public void av_free_packet(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Allocate new information of a packet.
		 *
		 * @param pkt packet
		 * @param type side information type
		 * @param size side information size
		 * @return pointer to fresh allocated data or NULL otherwise
		 */
		static public Unimplemented av_packet_new_side_data;
		/*
		uint8_t* av_packet_new_side_data(AVPacket pkt, AVPacketSideDataType type, int size)
		{
			throw(new NotImplementedException());
		}
		*/

		/**
		 * Shrink the already allocated side data buffer
		 *
		 * @param pkt packet
		 * @param type side information type
		 * @param size new side information size
		 * @return 0 on success, < 0 on failure
		 */
		static public int av_packet_shrink_side_data(AVPacket pkt, AVPacketSideDataType type, int size)
		{
			throw(new NotImplementedException());
		}

		/**
		 * Get side information from packet.
		 *
		 * @param pkt packet
		 * @param type desired side information type
		 * @param size pointer for side information size to store (optional)
		 * @return pointer to data if present or NULL otherwise
		 */
		static public Unimplemented av_packet_get_side_data;
		/*
		uint8_t* av_packet_get_side_data(AVPacket *pkt, enum AVPacketSideDataType type, int *size);
		{
			throw(new NotImplementedException());
		}
		*/

		static public int av_packet_merge_side_data(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}

		static public int av_packet_split_side_data(AVPacket pkt)
		{
			throw(new NotImplementedException());
		}
	}
}
